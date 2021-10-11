//you will be using the using 
using System.Runtime.InteropServices;

//Before we begin you must understand you cannot truely import CPP.
//Only static functions and structs for data can be imported. This
//may mean writeing a quick CCP class to static name space wrapper
//on the CPP side and then importing. This may take passing a 
//pointer to the class its self and passing of structs for the data.

//Note that the .dll should be in the same folder as the C# directory
//or registered with your OS

//Importing a static Function to a method. You may want to wrap the functions
//with a more C# frendly method to get the types to play well together in C#
//For indstance I have seen methods in CPP where two calls are required
//one for a count and one for the array list its self. This could be
//method wrapped to call both times for a single call using a special contianer in C#.
//but the below is the import type table
//Note that the .dll should be in the same folder as the C# directory
//or registered with your OS
[DllImport("TheSource.dll", EntryPoint = "TheCPPFunction")]
static extern int/*Return type must match your CPP return*/ 
YourInitImportSignature(/*any params that match your CPP params*/);
//Type Equiviants rough (you can sometimes interchange them or usage may change them)
// CPP                C#
// char               byte or char
// short              short
// unsigned short     ushort
// int                int or IntPtr(as a underef pointer) or EnumType
// unsigned int       uint
// long int           long
// unsigned long int  ulong
// double             double
// short              short
//Special type modifiers
//CPP                   C#
//*(pointer)type        Type[] or IntPtr or StructLayout(LayoutKind.Sequential) marked struct
//*(pointer)char        char[] and/or string
//&(reference)type      ref type and/or out
//Note Enums can be in int places but must be cast with a wrapping class 
//after ecxternal import as C++ will treat them as ints in use.

//Importing a struct
[StructLayout(LayoutKind.Sequential)]
struct YourLayoutOfCPPStrunct
{
  //Add your properties as is the same in the C++ class in the squent order
  public string FistTextLocation;
  public int SecondInt;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
  public byte[] LoctionArrays;
}
// you can mostly follow the above equivalants, but arrays must now be give 
// a size according to the CPP's values.
//Some of this will be detective work and a guessing game to see what imports propertly.