function Build-Folder($folder)
{
	pushd $folder
	cd rust
	cargo build -r
	cd ../c
	cmake -S. -Bbuild
	cmake --build build --config Release
	cd ../naot
	dotnet publish
	cd ../go
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

$experiments = @("baseline", "sum_strings", "parse_float", "strreverse", "tolower", "strempty")
#$experiments = @("strempty")
foreach ($experiment in $experiments) {
	Build-Folder $experiment
}

foreach ($experiment in $experiments) {
	Measure-Folder $experiment
}

