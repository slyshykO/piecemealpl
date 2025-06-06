param(
	$Experiment
)
function Build-Folder($folder)
{
	echo "===== Building $folder ====="
	pushd $folder
	cd rust
	cargo build -r
	cd ../c
	if (Test-Path "vcpkg.json") {
		cmake -S. -Bbuild -DCMAKE_TOOLCHAIN_FILE="$env:VCPKG_ROOT/scripts/buildsystems/vcpkg.cmake" -DVCPKG_TARGET_TRIPLET=x64-windows-static
	} else {
		cmake -S. -Bbuild
	}
	
	cmake --build build --config Release
	cd ../naot
	dotnet publish
	cd ../go
	go mod tidy
	go build -o out/ -ldflags "-s -w"
	cd ..
	popd
}

function Measure-Folder($folder)
{
	ls $folder/c/build/Release/*.exe | Select-Object Name, Length
	ls $folder/rust/target/release/*.exe | Select-Object Name, Length
	ls $folder/naot/bin/Release/net10.0/win-x64/publish/*.exe | Select-Object Name, Length
	ls $folder/go/out/*.exe | Select-Object Name, Length
}

if (-not $env:VCPKG_ROOT) {
	$env:VCPKG_ROOT = "C:\Program Files\Microsoft Visual Studio\2022\Preview\VC\vcpkg"
}

$experiments = @("baseline", "sum_strings", "parse_float", "strreverse", "tolower", "strempty", "arrayinit", "cmdlineargs",
	"readfile", "archivefile", "createfile", 
	#"sdl2", # Go and Rust version does not compiled
	"win32_window")
if ($Experiment) {
		$experiments = @($Experiment)
}
#$experiments = @("createfile")
foreach ($experiment in $experiments) {
	Build-Folder $experiment
}

foreach ($experiment in $experiments) {
	Measure-Folder $experiment
}

