#include <bits/stdc++.h>
using namespace std;

int main() {
    int n;
    cin >> n;

    vector<int> a(n);
    for (int i = 0; i < n; i++)
        cin >> a[i];

    int l = 0, r = n - 1;
    int sereja = 0, dima = 0;
    bool turn = true; // true -> Sereja, false -> Dima

    while (l <= r) {
        int take;
        if (a[l] > a[r]) {
            take = a[l];
            l++;
        } else {
            take = a[r];
            r--;
        }

        if (turn)
            sereja += take;
        else
            dima += take;

        turn = !turn;
    }

    cout << sereja << " " << dima;
    return 0;
}
