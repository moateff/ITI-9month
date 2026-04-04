#include <iostream>
#include <vector>

using namespace std;

int main() {
    int n, m;
    cin >> n >> m;

    vector<bool> covered(m + 1, false); // points from 1 to m

    for (int i = 0; i < n; i++) {
        int l, r;
        cin >> l >> r;
        for (int x = l; x <= r; x++) {
            covered[x] = true;
        }
    }

    vector<int> result;
    for (int x = 1; x <= m; x++) {
        if (!covered[x]) {
            result.push_back(x);
        }
    }

    cout << result.size() << endl;
    for (int x : result) {
        cout << x << " ";
    }
    if (!result.empty()) cout << endl;

    return 0;
}
