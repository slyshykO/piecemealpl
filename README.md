Example projects for measuring the code size of the different primitive software operations
==========================

```
cd rust
cargo build -r
cd ../c
cmake -S. -Bbuild
cmake --build build --config Release
cd ..

ls c/build/Release/*.exe
ls rust/target/release/*.exe
```