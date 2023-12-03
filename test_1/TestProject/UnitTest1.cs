using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {

        public void Main1()
        {
            var arr = new byte[100];
            _ = arr.AsSpan(start: 20);
            _ = new Span<byte>(arr, 20, arr.Length - 20);
            _ =
             MemoryMarshal.CreateSpan<byte>(ref arr[20], arr.Length - 20);

            int length = 0;
            Span<byte> bytes = length <= 128 ? stackalloc byte[length] : new byte[length];
            //... // Code that operates on the Span<byte>
        }

        private static async Task<int> ChecksumReadAsync(Memory<byte> buffer, Stream stream)
        {
            int bytesRead = await stream.ReadAsync(buffer);
            return Checksum(buffer.Span.Slice(0, bytesRead));
            // Or buffer.Slice(0, bytesRead).Span
        }

        private static int Checksum(Span<byte> buffer) { return -1; }

        ////static Span<char> FormatGuid(Guid guid)
        ////{
        ////    Span<char> chars = stackalloc char[100];
        ////    bool formatted = guid.TryFormat(chars, out int charsWritten, "d");
        ////    Debug.Assert(formatted);
        ////    return chars[..charsWritten]; // Uh oh
        ////}

        [TestMethod]
        public void UnsafePlayground()
        {
            unsafe
            {
                byte[] bytes = [1, 2, 3];
                fixed (byte* pointerToFirst = bytes)
                {
                    Console.WriteLine($"The address of the first array element: {(long)pointerToFirst:X}.");
                    Console.WriteLine($"The value of the first array element: {*pointerToFirst}.");
                }
            }
            // Output is similar to:
            // The address of the first array element: 2173F80B5C8.
            // The value of the first array element: 1.

            unsafe
            {
                int[] numbers = [10, 20, 30];
                fixed (int* toFirst = &numbers[0], toLast = &numbers[^1])
                {
                    Console.WriteLine(toLast - toFirst);  // output: 2
                }
            }

            unsafe
            {
                int[] numbers = [10, 20, 30, 40, 50];
                Span<int> interior = numbers.AsSpan()[1..^1];
                fixed (int* p = interior)
                {
                    for (int i = 0; i < interior.Length; i++)
                    {
                        Console.Write(p[i]);
                    }
                    // output: 203040
                }
            }

            unsafe
            {
                var message = "Hello!";
                fixed (char* p = message)
                {
                    Console.WriteLine(*p);  // output: H
                }
            }

            // Normal pointer to an object.
            int[] a = [10, 20, 30, 40, 50];
            // Must be in unsafe code to use interior pointers.
            unsafe
            {
                // Must pin object on heap so that it doesn't move while using interior pointers.
                fixed (int* p = &a[0])
                {
                    // p is pinned as well as object, so create another pointer to show incrementing it.
                    int* p2 = p;
                    Console.WriteLine(*p2);
                    // Incrementing p2 bumps the pointer by four bytes due to its type ...
                    p2 += 1;
                    Console.WriteLine(*p2);
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");
                    Console.WriteLine(*p);
                    // Dereferencing p and incrementing changes the value of a[0] ...
                    *p += 1;
                    Console.WriteLine(*p);
                    *p += 1;
                    Console.WriteLine(*p);
                }
            }

            Console.WriteLine("--------");
            Console.WriteLine(a[0]);

            /*
            Output:
            10
            20
            30
            --------
            10
            11
            12
            --------
            12
            */
        }

        [TestMethod]
        public void TestMethod1()
        {
            IntPtr ptr = Marshal.AllocHGlobal(1);
            try
            {
                Span<byte> bytes;
                unsafe { bytes = new Span<byte>((byte*)ptr, 1); }
                bytes[0] = 42;
                Assert.AreEqual(42, bytes[0]);
                Assert.AreEqual(Marshal.ReadByte(ptr), bytes[0]);
                bytes[1] = 43; // Throws IndexOutOfRangeException
            }
            finally { Marshal.FreeHGlobal(ptr); }


        }

        private struct MutableStruct<T> { public T Value; }

        [TestMethod]
        public void TestMethod2()
        {
            Span<MutableStruct<int>> spanOfStructs = new MutableStruct<int>[1];
            spanOfStructs[0].Value = 42;
            Assert.AreEqual(42, spanOfStructs[0].Value);
            var listOfStructs = new List<MutableStruct<int>> { new() };
            //listOfStructs[0].Value = 42; // Error CS1612: the return value is not a variable

            var ms = new MutableStruct<int>
            {
                Value = 42
            };
            listOfStructs[0] = ms;
        }

        [TestMethod]
        public void TestMethod3()
        {
            string str = "hello, world";
            _ = str.Substring(startIndex: 7, length: 5); // Allocates
            ReadOnlySpan<char> worldSpan =
              str.AsSpan().Slice(start: 7, length: 5); // No allocation
            Assert.AreEqual('w', worldSpan[0]);
            //worldSpan[0] = 'a'; // Error CS0200: indexer cannot be assigned to
        }

    }

    [TestClass]
    public class Example
    {
        private const int segmentSize = 10;

        [TestMethod]
        public async Task Main2()
        {
            List<Task> tasks = new List<Task>();

            // Create array.
            int[] arr = new int[50];
            for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
                arr[ctr] = ctr + 1;

            // Handle array in segments of 10.
            for (int ctr = 1; ctr <= Math.Ceiling(((double)arr.Length) / segmentSize); ctr++)
            {
                int multiplier = ctr;
                int elements = ((multiplier - 1) * 10) + segmentSize > arr.Length ?
                                arr.Length - ((multiplier - 1) * 10) : segmentSize;
                ArraySegment<int> segment = new ArraySegment<int>(arr, (ctr - 1) * 10, elements);
                tasks.Add(Task.Run(() =>
                {
                    IList<int> list = (IList<int>)segment;
                    for (int index = 0; index < list.Count; index++)
                        list[index] = list[index] * multiplier;
                }));
            }
            try
            {
                await Task.WhenAll(tasks.ToArray());
                int elementsShown = 0;
                foreach (var value in arr)
                {
                    Console.Write("{0,3} ", value);
                    elementsShown++;
                    if (elementsShown % 18 == 0)
                        Console.WriteLine();
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Errors occurred when working with the array:");
                foreach (var inner in e.InnerExceptions)
                    Console.WriteLine("{0}: {1}", inner.GetType().Name, inner.Message);
            }
        }
    }
    // The example displays the following output:
    //      1   2   3   4   5   6   7   8   9  10  22  24  26  28  30  32  34  36
    //     38  40  63  66  69  72  75  78  81  84  87  90 124 128 132 136 140 144
    //    148 152 156 160 205 210 215 220 225 230 235 240 245 250
}