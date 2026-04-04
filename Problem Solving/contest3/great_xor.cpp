#include <bits/stdc++.h>
using namespace std;

int highest_set_bit(long long x) {
    for (int i = 63; i >= 0; i--) {
        if (((x >> i) & 1LL) == 1) {
            return i;
        }
    }
    return -1;
}

int main() {
    int t;
    cin >> t;

    while (t--) {
        long long x;
        cin >> x;

        long long ans = 0;

        int msb = highest_set_bit(x);
        cout << msb << endl;

        for (int i = 0; i < msb; i++) {
            if (((x >> i) & 1LL) == 0) {
                ans += (1LL << i);
            }
        }

        cout << ans << "\n";
    }

    return 0;
}
