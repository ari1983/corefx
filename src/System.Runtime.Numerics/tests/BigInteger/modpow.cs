// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using Tools;
using Xunit;

namespace System.Numerics.Tests
{
    public class modpowTest
    {
        private static int s_samples = 10;
        private static Random s_random = new Random(100);

        [Fact]
        public static void ModPowValidSmallNumbers()
        {
            BigInteger result;
            bool b = BigInteger.TryParse("22", out result);

            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];

            // ModPow Method - with small numbers - valid
            for (int i = 1; i <= 1; i++)//-2
            {
                for (int j = 0; j <= 1; j++)//2
                {
                    for (int k = 1; k <= 1; k++)
                    {
                        if (k != 0)
                        {
                            VerifyModPowString(k.ToString() + " " + j.ToString() + " " + i.ToString() + " tModPow");
                        }
                    }
                }
            }
        }

        [Fact]
        public static void ModPowNegative()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];


            // ModPow Method - with small numbers - invalid - zero modulus
            for (int i = -2; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Assert.Throws<DivideByZeroException>(() =>
                    {
                        VerifyModPowString(BigInteger.Zero.ToString() + " " + j.ToString() + " " + i.ToString() + " tModPow");
                    });
                }
            }

            // ModPow Method - with small numbers - invalid - negative exponent
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= -1; j++)
                {
                    for (int k = -2; k <= 2; k++)
                    {
                        if (k != 0)
                        {
                            Assert.Throws<ArgumentOutOfRangeException>(() =>
                            {
                                VerifyModPowString(k.ToString() + " " + j.ToString() + " " + i.ToString() + " tModPow");
                            });
                        }
                    }
                }
            }

            // ModPow Method - Negative Exponent
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomNegByteArray(s_random, 2);
                tempByteArray3 = GetRandomByteArray(s_random);
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    VerifyModPowString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow");
                });
            }

            // ModPow Method - Zero Modulus
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomPosByteArray(s_random, 1);
                Assert.Throws<DivideByZeroException>(() =>
                {
                    VerifyModPowString(BigInteger.Zero.ToString() + " " + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow");
                });
            }
        }

        [Fact]
        public static void ModPow3SmallInt()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];


            // ModPow Method - Three Small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomPosByteArray(s_random, 2);
                tempByteArray3 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow"), " Verification Failed");
            }
        }

        [Fact]
        public static void ModPow1Large2SmallInt()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];

            // ModPow Method - One large and two small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomPosByteArray(s_random);
                tempByteArray3 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomPosByteArray(s_random, 2);
                tempByteArray3 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomPosByteArray(s_random, 1);
                tempByteArray3 = GetRandomByteArray(s_random);
                Assert.True(VerifyModPowString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow"), " Verification Failed");
            }
        }

        [Fact]
        public static void ModPow2Large1SmallInt()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];


            // ModPow Method - Two large and one small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomPosByteArray(s_random);
                tempByteArray3 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow"), " Verification Failed");
            }
        }

        [Fact]
        public static void ModPow0Power()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];


            // ModPow Method - zero power
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + BigInteger.Zero.ToString() + " " + Print(tempByteArray1) + "tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + BigInteger.Zero.ToString() + " " + Print(tempByteArray1) + "tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + BigInteger.Zero.ToString() + " " + Print(tempByteArray1) + "tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + BigInteger.Zero.ToString() + " " + Print(tempByteArray1) + "tModPow"), " Verification Failed");
            }
        }

        [Fact]
        public static void ModPow0Base()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];


            // ModPow Method - zero base
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomPosByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + Print(tempByteArray1) + BigInteger.Zero.ToString() + " tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomPosByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + Print(tempByteArray1) + BigInteger.Zero.ToString() + " tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomPosByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + Print(tempByteArray1) + BigInteger.Zero.ToString() + " tModPow"), " Verification Failed");

                tempByteArray1 = GetRandomPosByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random);
                Assert.True(VerifyModPowString(Print(tempByteArray2) + Print(tempByteArray1) + BigInteger.Zero.ToString() + " tModPow"), " Verification Failed");
            }
        }

        [Fact]
        public static void ModPowAxiom()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];


            // Axiom (x^y)%z = modpow(x,y,z)
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomPosByteArray(s_random, 1);
                tempByteArray3 = GetRandomByteArray(s_random);
                Assert.True(VerifyIdentityString(Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "tModPow",
                                            Print(tempByteArray3) + Print(tempByteArray2) + Print(tempByteArray1) + "bPow" + " bRemainder"), "Test Failed");
            }
        }


        [Fact]
        public static void ModPowBoundary()
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];
            byte[] tempByteArray3 = new byte[0];

            //Check interesting cases for boundary conditions
            //You'll either be shifting a 0 or 1 across the boundary
            // 32 bit boundary  n2=0
            Assert.True(VerifyModPowString(Math.Pow(2, 35) + " " + Math.Pow(2, 32) + " 2 tModPow"), " Verification Failed");

            // 32 bit boundary  n1=0 n2=1
            Assert.True(VerifyModPowString(Math.Pow(2, 35) + " " + Math.Pow(2, 33) + " 2 tModPow"), " Verification Failed");
        }


        private static bool VerifyModPowString(string opstring)
        {
            bool ret = true;
            StackCalc sc = new StackCalc(opstring);

            while (sc.DoNextOperation())
            {
                ret &= Eval(sc.snCalc.Peek().ToString(), sc.myCalc.Peek().ToString(), String.Format("Out of Sync stacks found.  BigInteger {0} Mine {1}", sc.snCalc.Peek(), sc.myCalc.Peek()));
            }
            return ret;
        }
        private static bool VerifyIdentityString(string opstring1, string opstring2)
        {
            bool ret = true;

            StackCalc sc1 = new StackCalc(opstring1);
            while (sc1.DoNextOperation())
            {	//Run the full calculation
                sc1.DoNextOperation();
            }

            StackCalc sc2 = new StackCalc(opstring2);
            while (sc2.DoNextOperation())
            {	//Run the full calculation
                sc2.DoNextOperation();
            }

            ret &= Eval(sc1.snCalc.Peek().ToString(), sc2.snCalc.Peek().ToString(), String.Format("Out of Sync stacks found.  BigInteger1: {0} BigInteger2: {1}", sc1.snCalc.Peek(), sc2.snCalc.Peek()));

            return ret;
        }

        private static Byte[] GetRandomByteArray(Random random)
        {
            return GetRandomByteArray(random, random.Next(1, 100));
        }
        private static Byte[] GetRandomPosByteArray(Random random)
        {
            return GetRandomPosByteArray(random, random.Next(1, 100));
        }
        private static Byte[] GetRandomByteArray(Random random, int size)
        {
            byte[] value = new byte[size];

            while (IsZero(value))
            {
                for (int i = 0; i < value.Length; ++i)
                {
                    value[i] = (byte)random.Next(0, 256);
                }
            }

            return value;
        }
        private static Byte[] GetRandomPosByteArray(Random random, int size)
        {
            byte[] value = new byte[size];

            for (int i = 0; i < value.Length; ++i)
            {
                value[i] = (byte)random.Next(0, 256);
            }
            value[value.Length - 1] &= 0x7F;

            return value;
        }
        private static Byte[] GetRandomNegByteArray(Random random, int size)
        {
            byte[] value = new byte[size];

            for (int i = 0; i < value.Length; ++i)
            {
                value[i] = (byte)random.Next(0, 256);
            }
            value[value.Length - 1] |= 0x80;

            return value;
        }
        private static bool IsZero(byte[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] != 0)
                    return false;
            }
            return true;
        }

        private static String Print(byte[] bytes)
        {
            String ret = "make ";

            for (int i = 0; i < bytes.Length; i++)
            {
                ret += bytes[i] + " ";
            }
            ret += "endmake ";

            return ret;
        }

        public static bool Eval<T>(T expected, T actual, String errorMsg)
        {
            bool retValue = expected == null ? actual == null : expected.Equals(actual);

            if (!retValue)
                return Eval(retValue, errorMsg +
                " Expected:" + (null == expected ? "<null>" : expected.ToString()) +
                " Actual:" + (null == actual ? "<null>" : actual.ToString()));

            return true;
        }

        public static bool Eval(bool expression, string message)
        {
            if (!expression)
            {
                Console.WriteLine(message);
            }

            return expression;
        }
    }
}
