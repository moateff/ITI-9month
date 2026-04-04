#include <iostream>
using namespace std;

int main() {
    int n;
    cin >> n;

    char s[n];
    cin >> s;

    int arr[26] = {0};
    for (int i = 0; i < n; i++) {
        if (s[i] >= 'a' && s[i] <= 'z') {
            arr[s[i] - 'a']++;
        } else {
            arr[s[i] - 'A']++;
        }
    }

    for (int i = 0; i < 26; i++) {
        if (arr[i] == 0) {
            cout << "NO" << endl;
            return 0;
        }
    }
    cout << "YES" << endl;

    return 0;
}