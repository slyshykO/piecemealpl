use std::env;

fn main() {
    for item in env::args() {
        println!("{item}");
    }
    println!("Hello, world!");
}
