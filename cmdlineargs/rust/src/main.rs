use std::env;

fn main() {
    for item in env::args().enumerate() {
        let (_i, x): (usize, String) = item;
        println!("{x}");
    }
    println!("Hello, world!");
}
