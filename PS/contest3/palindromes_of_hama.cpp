#include <bits/stdc++.h>
using namespace std;

const long long NMAX = 1000000000LL;
const long long S_MAX = NMAX * (NMAX + 1) / 2;

int main() {
    vector<long long> pref;
    pref.push_back(0); // dummy for 1-based indexing

    auto make_pal = [](long long x, bool odd) {
        long long res = x;
        if (odd) x /= 10;
        while (x) {
            res = res * 10 + (x % 10);
            x /= 10;
        }
        return res;
    };

    long long sum = 0;

    for (int len = 1; ; len++) {
        int half = (len + 1) / 2;
        long long start = 1;
        for (int i = 1; i < half; i++) start *= 10;
        long long end = start * 10 - 1;

        for (long long x = start; x <= end; x++) {
            long long p = make_pal(x, len % 2);

            sum += p;
            pref.push_back(sum);

            if (sum > S_MAX) break;
        }

        if (sum > S_MAX) break;
    }

    int t;
    cin >> t;

    while (t--) {
        long long n;
        cin >> n;

        long long S = n * (n + 1) / 2;

        int k = upper_bound(pref.begin() + 1, pref.end(), S) - pref.begin() - 1;

        for (auto &p : pref) {
            cout << p << " ";            
        }
        cout << endl;

        if (k > n) k = (int)n;

        cout << k << endl;
    }

    return 0;
}
