#include <bits/stdc++.h>
using namespace std;

int main() {
    int N;
    cin >> N;

    string S;
    cin >> S;

    unordered_map<char, int> freq;

    for (char c : S) {
        freq[c]++;
    }

    int ans = 0;
    for (auto &p : freq) {
        ans += p.second / 2;
    }

    cout << ans << endl;

    return 0;
}
