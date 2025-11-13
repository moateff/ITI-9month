#include <iostream>

int main(){
    // 1.
    std::cout << "My name: Mohamed Atef Yousef" << std::endl;
    std::cout << "My age: 23-year-old" << std::endl;
    std::cout << "My city: Alexandria" << std::endl;

    std::cout << std::endl;

    // 2. 
    int num1, num2;
    std::cout << "Enter first number = ";
    std::cin >> num1;
    std::cout << "Enter second number = ";
    std::cin >> num2;
    std::cout << "num1 + num2 = " << num1 + num2 << std::endl;
    std::cout << "num1 - num2  = " << num1 - num2 << std::endl;
    std::cout << "avg(num1, num2) = " << (num1 + num2) / 2 << std::endl;

    std::cout << std::endl;

    // 3. 
    int decimal;
    std::cout << "Enter decimal number : ";
    std::cin >> decimal;

    std::cout << "Number in hexadecimal format = 0x" << std::hex << decimal << std::endl;
    std::cout << "Number in octal format = 0h" << std::oct << decimal << std::endl;

    std::cout << std::endl;

    // 4.
    char character;
    std::cout << "Enter a character : ";
    std::cin >> character;
    std::cout << "Character in ASCII representation = " << std::dec << int(character) << std::endl;
    return 0;
}