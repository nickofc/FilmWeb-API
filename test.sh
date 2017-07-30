#!/bin/bash

set -x

mono packages/NUnit.Runners.2.6.4/tools/nunit-console.exe bin/FilmWebAPI.Test.dll
