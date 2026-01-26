#include <iostream>
#include <set>
#include <string>
using namespace std;

int main() {
    string s;
    getline(cin, s); // read whole line

    set<char> letters;

    for (char c : s) {
        // Only add lowercase letters
        if (c >= 'a' && c <= 'z') {
            letters.insert(c);
        }
    }

    cout << letters.size() << endl;
    return 0;
}
