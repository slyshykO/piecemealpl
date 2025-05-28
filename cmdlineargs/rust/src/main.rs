use std::env;

fn main() {
    let args: Vec<String> = env::args().collect();
    for item in args.into_iter().enumerate() {
        let (_i, x): (usize, String) = item;
        println!("{x}");
    }
    println!("Hello, world!");
}
