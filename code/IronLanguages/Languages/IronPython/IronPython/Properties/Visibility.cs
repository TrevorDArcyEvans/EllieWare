/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the  Apache License, Version 2.0, please send an email to 
 * dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 *
 * ***************************************************************************/
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System;

[assembly: InternalsVisibleTo("IronPython.Modules, PublicKey=0024000004800000940000000602000000240000525341310004000001000100136636bf42f0678fe9102de5b76ce8871e47d47dedd8a6f965a0666c4ea54a159167895d7a6422f31851a086a2fe6a700c95635a5d8c9795c41204e0905008c8bfade87edf886744b242b89a4b20f8cbd60186b4f427246a505a1a3c6371ad8b3b529c3e322b8caf14bd2174f8062b2bde59c84e882178b9c2c9dd3e99b4a6b6")]
[assembly: InternalsVisibleTo("IronPythonTest, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c10ce00dd2e0ce5046d68183d3ad035b47e92bf0ce7bcf8a03a217ca5d0b0c7db973fdf97579b52b502a23d4069dbf043389e1ab65a1d6c508a9837f3e2350f15e05cc63c0fc4b0410867a51919090e4c33f80203e9b0035b21c32bae20f98b068f90d99a50133a5336480d94039b176519f5fd8524765f33be43da65c4b68ba")]

#if FEATURE_APTCA
[assembly: AllowPartiallyTrustedCallers]
#endif
