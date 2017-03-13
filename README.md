### CPMX7 Geekness Virus Challenge  

Given a population of patients, determine the percentage of the population that is infected of the Geekness Virus. You will receive a list of files that contains patients DNA. Each DNA is in the form of a String composed of a sequence of characters A, C, G, T.

To determine if a patient is infected, the number of occurrences of ​T​ in their DNA needs to be greater than the number of all the other letters.

#### Example 1

In the sequence TTTAACCGG, we can determine that the patient is infected because:

Ocurrences of A: 2
Ocurrences of C: 2
Ocurrences of G: 2
Ocurrences of T: 3
T is the dominant letter in the sequence, therefore the patient is infected.

#### Example 2

In the sequence TTCCGGAA, we can determine that the patient is healthy because:

Ocurrences of A: 2
Ocurrences of C: 2
Ocurrences of G: 2
Ocurrences of T: 2
T is not the dominant letter, therefore the patient is not infected.

#### Game rules

Write a program that calculates the percentage of the population that is infected.
sicknessPercentage = number of infected patients / number of patients
The sicknessPercentage should be an integer value from 0 to 100.
Round the percentage value down to make it an integer (i.e. 66.66 should be rounded to 66).
Each patient's DNA will be in the form of text file that your code needs to download from a URL.
The faster your program finds the solution, the better score you will get.

