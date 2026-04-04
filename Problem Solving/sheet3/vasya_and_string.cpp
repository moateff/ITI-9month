#include <bits/stdc++.h>
using namespace std;

int solve(const string& s, int k, char target) {
    int l = 0, count = 0, best = 0;

    for (int r = 0; r < (int)s.size(); r++) {
        if (s[r] != target)
            count++;

        while (count > k) {
            if (s[l] != target)
                count--;
            l++;
        }

        best = max(best, r - l + 1);
    }

    return best;
}

int main() {
    int n, k;
    cin >> n >> k;

    string s;
    cin >> s;

    int ans = max(solve(s, k, 'a'), solve(s, k, 'b'));

    cout << ans << endl;
    return 0;
}