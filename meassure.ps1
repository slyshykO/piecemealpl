function Build-Folder($folder)
{
	pushd $folder
	cd rust
	cargo build -r
	cd ../c
	cmake -S. -Bbuild
	cmake --build build --config Release
	cd ..
	popd
}

function Measure-Folder($folder)
{
	ls $folder/c/build/Release/*.exe | Select-Object Name, Length
	ls $folder/rust/target/release/*.exe | Select-Object Name, Length
}

$experiments = @("baseline", "sum-strings", "parse_float", "strreverse", "tolower", "strempty")
foreach ($experiment in $experiments) {
	Build-Folder $experiment
}

foreach ($experiment in $experiments) {
	Measure-Folder $experiment
}

