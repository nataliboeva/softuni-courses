function checkIfPositive(numOne,numTwo,numThree){
    let negativeCount = 0;
    if (numOne < 0){
        negativeCount++;
    }
    if(numTwo < 0){
        negativeCount++;
    }
    if(numThree < 0){
        negativeCount++;
    }
    if(negativeCount % 2 != 0){
        console.log('Negative');
    }
    else{
        console.log('Positive');
    }
}
checkIfPositive(5,12,-15);
checkIfPositive(-6,-12,14);
checkIfPositive(-1,-2,-3);
checkIfPositive(-5,1,1);