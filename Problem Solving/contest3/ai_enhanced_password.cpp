#include <bits/stdc++.h>
using namespace std;

int main() {
    string S;
    cin >> S;

    int n = S.size();

    for (int L = n + 1; L <= n + 10; L++) {
        int digits = to_string(L).size();
        if (n + digits == L) {
            cout << S << L << endl;
            break;
        }
    }

    return 0;
}
