#include <iostream>
#include <string>
#include <vector>

using namespace std;

bool isEven (int num) {
    return num % 2 == 0;
}

int distinctCount(string s) {
    vector<char> v;
    v.push_back(s[0]);

    bool found;

    for (int i = 1; i < s.size(); i++) {
        found = false;
        for (int j = 0; j < v.size(); j++) {
            if (s[i] == v[j]) found = true;
        }
        if (found) continue;
        else v.push_back(s[i]);
    }

    return v.size();
}

int main() {
    string username;
    cin >> username;

    if (isEven(distinctCount(username))) {
        cout << "CHAT WITH HER!" << endl;
    } else {
        cout << "IGNORE HIM!" << endl;
    }
    
    return 0;

}
