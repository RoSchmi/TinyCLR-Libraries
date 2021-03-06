namespace System.Reflection {

    using System;
    using System.Runtime.CompilerServices;

    // This is defined to support VarArgs
    //typedef ArgIterator  va_list;
    [Serializable()]
    internal sealed class RuntimeMethodInfo : MethodInfo {
        public extern override Type ReturnType {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }
    }
}   // Namespace


