#include <iostream>
using namespace std;

int main(){
    int score;

    cout << "Enter your score (0 - 100): ";
    cin >> score;

    // Check for valid range
    if (score < 0 || score > 100) {
        cout << "Invalid score! Please enter a value between 0 and 100.\n";
        return 0;
    }

    cout << "Your grade is: ";

    if (score >= 90)
       cout << "A (Excellent)\n";
    else if (score >= 80)
        cout << "B (Very Good)\n";
    else if (score >= 70)
        cout << "C (Good)\n";
    else if (score >= 60)
        cout << "D (Pass)\n";
    else
        cout << "F (Fail)\n";

    return 0;
}