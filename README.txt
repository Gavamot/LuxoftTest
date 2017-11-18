Task: Combinations
Need to implement a console application which produces the list of combinations of words from the input file. Please send the result of the task in form of MS VS 2012 or 2015 solution.
An application receives two inputs: a) path to input file (i.e. "C:\\input.xml"); b) path to output file to store the results (i.e. "D:\\output.xml")
Input file provides the list of words and minimum-maximum number of words in the combination - see format below:
--- INPUT.XML ----------------------------------
<input>
<range>
<min>1</min>
<max>4</max>
<range>
<words>
<word>A</word>
<word>B</word>
<word>C</word>
<word>D</word>
<word>E</word>
<word>F</word>
</words>
<input>
------------------------------------------------
Other example:
--- INPUT.XML ----------------------------------
<input>
<range>
<min>3</min>
<max>6</max>
<range>
<words>
<word>JOHN</word>
<word>TED</word>
<word>BILL</word>
<word>JACK</word>
<word>ALBERT</word>
<word>MAX</word>
</words>
<input>
------------------------------------------------
As an output the program should produce all possible combinations with number of words between minimum and maximum specified and store them into the output file - for example:
--- OUTPUT.XML ---------------------------------
<output>
<combinations>
<combination>A</combination>
<combination>B</combination>
<combination>C</combination>
    .....
<combination>A B</combination>
<combination>A C</combination>
    ....
<combination>A B C D</combination>
<combination>A C D E</combination>
    ....
</combinations>
</output>
------------------------------------------------
Constraints:
- there should be no duplications of words in combination - for example combination "A A B" is invalid
- order of words doesn't matter - combinations "A B" and "B A" are treated as the same and only one of them should appear in the results
Additional requirements:
- Show the good coding style and the design approach - re-usability, extensibility, modularity
- Consider proper error handling and checks
- Cover the code with the unit tests
- Show the best of your skills!
