fn main() {
    let string1 = String::from("Hello, ");
    let string2 = "world!";
    let result = format!("{}{}", string1, string2);
    println!("{}", result);
}
