#include <iostream>
using namespace std;

int main() {
    long long n;
    cin >> n;

    long long freq[10] = {0};

    for (long long i = 0; i <= n; i++)  {
        long long freqNew[10] = {0};

        long long temp = i;
        do {
            int d = temp % 10;
            freqNew[d]++;
            temp /= 10;
        } while (temp > 0);

        for (int i = 0; i < 10; i++) {
            if (freqNew[i] > freq[i]) {
                freq[i] = freqNew[i];
            }
        }
    }

    long long count = 0;
    for (int i = 0; i < 10; i++) {
        if (freq[i]) count += freq[i];
    }

    cout << count << endl;
        
    return 0;
}