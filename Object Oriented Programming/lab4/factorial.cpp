#include <iostream>
using namespace std;

long long factorialRecursive(int n) {
    if (n <= 1)
        return 1;  // Base case: 0! = 1, 1! = 1
    else
        return n * factorialRecursive(n - 1); 
}

long long factorialIterative(int n) {
    long long fact = 1;
    for (int i = 1; i <= n; ++i) {
        fact *= i;
    }
    return fact;
}

int main() {
    int n;

    cout << "Enter a positive integer: ";
    cin >> n;

    if (n < 0) {
        cout << "Error: Factorial is not defined for negative numbers!" << endl;
        return 0;
    }

    cout << "Factorial of " << n << " (Recursive) = " << factorialRecursive(n) << endl;
    cout << "Factorial of " << n << " (Iterative) = " << factorialIterative(n) << endl;
    cout << endl;

    return 0;
}
