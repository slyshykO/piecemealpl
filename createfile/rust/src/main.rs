use std::fs::OpenOptions;

fn main() {
    let file_path = "output.txt";
    let _ = OpenOptions::new()
        .create(true)
        .write(true)
        .open(file_path)
        .unwrap();

    println!("Hello, world!");
}
