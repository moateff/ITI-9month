#include <bits/stdc++.h>
using namespace std;

int main() {
    int n;
    cin >> n;

    vector<int> a(n);
    int max = 0;
    for (int i = 0; i < n; i++) {
        cin >> a[i];
        max = std::max(max, a[i]);
    }

    vector<int> freq(max + 1, 0);
    for (int x : a) freq[x]++;

    int q;
    cin >> q;

    while (q--) {
        long long k;
        cin >> k;

        long long count = 0;

        if (k <= max) {
            for (long long v = k; v <= max; v += k)
                count += freq[v];
        }

        if (count >= n - 1)
            cout << "YES" << endl;
        else
            cout << "NO" << endl;
    }

    return 0;
}
