#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, m;
    cin >> n >> m;

    vector<int> a(n);
    for (int i = 0; i < n; i++)
        cin >> a[i];

    vector<int> b(m);
    for (int j = 0; j < m; j++)
        cin >> b[j];
    
    int j = 0;
    long long max_dist = 0;

    for (int i = 0; i < n; i++) {
        while (j + 1 < m && llabs(b[j + 1] - a[i]) <= llabs(b[j] - a[i])) {
            j++;
        }

        long long dist = llabs(b[j] - a[i]);
        if (dist > max_dist) {
            max_dist = dist;
        }
    }
    cout << max_dist << endl;

    return 0;
}