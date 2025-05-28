function Measure-Folder($folder)
{
	pushd $folder
	cd rust
	cargo build -r
	cd ../c
	cmake -S. -Bbuild
	cmake --build build --config Release
	cd ..

	ls c/build/Release/*.exe | Select-Object Name, Length
	ls rust/target/release/*.exe | Select-Object Name, Length

	popd
}

Measure-Folder "baseline"
Measure-Folder "sum-strings"
