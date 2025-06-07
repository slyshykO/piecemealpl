use std::fs;

fn main() {
    let contents = fs::read_to_string("README.md").expect("Should have been able to read the file");

    println!("{}", contents);
    println!("Hello, world!");
}
