use std::env;
use clap::Parser;

/// Search for a pattern in a file and display the lines that contain it.
#[derive(Parser)]
struct Cli {
    /// The pattern to look for
    f: Option<String>,
    /// The path to the file to read
    i: Option<i32>,
    l: Option<i32>,
    r: Option<i32>,
}

fn main() {
    let args = Cli::parse();

    println!("filename: {:?}, option: {:?}, option: {:?}, option: {:?}", args.f, args.i, args.l, args.r)

}
