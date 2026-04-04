#include <bits/stdc++.h>
using namespace std;

int main() {
    int t;
    cin >> t;

    while (t--) {
        int n;
        cin >> n;

        vector<long long> a(n);
        for (int i = 0; i < n; i++) cin >> a[i];

        unordered_map<long long,int> count; // counts of non-zero values
        int distinct = 0;

        int l = 0;
        int ans = 0;

        for (int r = 0; r < n; r++) {

            if (a[r] != 0) {
                if (count[a[r]] == 0) distinct++;
                count[a[r]]++;
            }

            while (distinct > 1) {
                if (a[l] != 0) {
                    count[a[l]]--;
                    if (count[a[l]] == 0)
                        distinct--;
                }
                l++;
            }

            ans = max(ans, r - l + 1);
        }

        cout << ans << endl;
    }

    return 0;
}