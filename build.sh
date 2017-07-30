#!/bin/bash

set -x

rm -rf bin/
mkdir bin/

cp packages/NUnit.*/lib/nunit.framework.dll bin/

################################################################################

echo 'using System;' > assembly.cs
echo 'using System.Reflection;' >> assembly.cs
echo 'using System.Runtime.CompilerServices;' >> assembly.cs
echo '[assembly:AssemblyTitle ("FilmWebAPI")]' >> assembly.cs
echo '[assembly:AssemblyDescription ("Nieoficjanlny klient API")]' >> assembly.cs
echo '[assembly:AssemblyCopyright ("Sunnyline")]' >> assembly.cs
echo '[assembly:CLSCompliant (true)]' >> assembly.cs
echo '[assembly: AssemblyVersion ("1.0.0")]' >> assembly.cs

mcs \
-unsafe \
-debug \
-define:DEBUG \
-out:bin/FilmWebAPI.dll \
-target:library \
-recurse:assembly.cs \
-recurse:FilmWeb-API/FilmWebAPI/FilmWebAPI/*.cs \
/doc:bin/FilmWebAPI.xml \
-lib:bin/

rm assembly.cs

################################################################################

mcs \
-unsafe \
-debug \
-define:DEBUG \
-out:bin/FilmWebAPI.Test.dll \
-target:library \
-reference:FilmWebAPI.dll \
-reference:nunit.framework.dll \
-recurse:FilmWeb-API/FilmWebAPI/UnitTestProject1/*.cs \
-lib:bin/
