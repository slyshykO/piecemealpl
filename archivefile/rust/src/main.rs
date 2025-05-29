use std::io::prelude::*;
use zip::write::SimpleFileOptions;

fn main() {
    let path = std::path::Path::new("experiment.zip");
    let file = std::fs::File::create(path).unwrap();

    let mut zip = zip::ZipWriter::new(file);

    let options = SimpleFileOptions::default()
        .compression_method(zip::CompressionMethod::Stored)
        .unix_permissions(0o755);
    zip.start_file("test.csv", options).unwrap();
    zip.write_all(b"Hello World!").unwrap();

    zip.finish().unwrap();

    println!("Hello, world!");
}
