#include <bits/stdc++.h>
using namespace std;

int main() {
    string a, b;
    cin >> a >> b;

    for (int i = 0; i < (int)a.size(); i++) {
        char ca = tolower(a[i]);
        char cb = tolower(b[i]);

        if (ca < cb) {
            cout << -1 << endl;
            return 0;
        } else if (ca > cb) {
            cout << 1 << endl;
            return 0;
        }
    }

    cout << 0 << endl;
    return 0;
}