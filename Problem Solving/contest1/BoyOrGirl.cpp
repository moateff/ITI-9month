#include <iostream>
#include <set>
#include <string>

using namespace std;

int main() {
    string username;
    cin >> username;

    set<char> uniqueChars(username.begin(), username.end());

    if (uniqueChars.size() % 2 == 0)
        std::cout << "CHAT WITH HER!";
    else
        std::cout << "IGNORE HIM!";

    return 0;
}
