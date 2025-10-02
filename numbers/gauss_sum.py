# 5
def sum(n):
    return (n*(n+1)/2)

def slow_sum(n):
    total = 0
    for i in range(1, n+1):
        total += i
    return total

def estimate_pi(k):
    current = 3
    count = 1
    add = True
    for i in range(k):
        term = (4/(count+1)*(count+2)*(count+3))
        if add == True:
            current += term
        else:
            current -= term
        count += 2

    return current
    
        