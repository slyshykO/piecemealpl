fn main() {
    let s = "Hello, world!";
    let t = s.chars().rev().collect::<String>();
    println!("{}", t);
}
