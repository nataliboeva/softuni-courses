function replace(text, word){
    let censored = text.replaceAll(word, '*'.repeat(word.length));
    console.log(censored);
}
replace('A small sentence with some words', 'small');
replace('Find the hidden word', 'hidden');