function solve (words, sentence){
    const specialWords = words.split(', ');
    let result = sentence;
    specialWords.forEach((word) => {
        result = result.replace('*'.repeat(word.length), word);
    });
    console.log(result);
}

solve('great','softuni is ***** place for learning new programming languages')