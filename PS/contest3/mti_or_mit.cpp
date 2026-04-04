#include <bits/stdc++.h>
using namespace std;

int main() {
    int N;
    cin >> N;
    string S;
    cin >> S;

    string p1 = "mti", p2 = "mit";
    int ops1 = 0, ops2 = 0;

    for (int i = 0; i < N; i++) {
        if (S[i] != p1[i % 3]) ops1++;
        if (S[i] != p2[i % 3]) ops2++;
    }

    if (ops1 == ops2)
        cout << "FAKE" << endl;
    else if (ops1 < ops2)
        cout << "mti " << ops1 << endl;
    else
        cout << "mit " << ops2 << endl;
        
    return 0;
}
