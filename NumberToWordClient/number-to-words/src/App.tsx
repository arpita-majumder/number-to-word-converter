import { useState } from 'react';
import './App.css';

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

function App() {
    const [word, setWord] = useState<string>();
    const [amount, setAmount] = useState<string>();
    const [error, setError] = useState<string>();
    const apiBaseUrl = "https://localhost:7091/numbertoword/";

    const handleConvert = async () => {
        try {
            setWord("");
            setError("");

            if (amount === undefined || amount.trim() === "") {
                setError("Amount cannot be empty");
            return;
            }

            const response = await fetch(`${apiBaseUrl}ConvertNumberToWord/${amount}`);
            
            if (response.ok) {
                    const word = await response.text();
                    setWord(word);
            } else {
                    setError(await response.text());
            }
        } catch (error) {
            setError('Network error');
        }
    };

    return (
        <div className="App">
            <h1>Number to Words Converter</h1>
            <div className="input-section">
                <label style={{ marginRight: '10px' }}>Enter a Number:</label>
                <input
                    type="text"
                    value={amount}
                    onChange={(e) => setAmount(e.target.value)}
                    placeholder="e.g. 123.45"
                />
                <button onClick={handleConvert}>Convert</button>
            </div>
            <div className="output-section">
                {word && <p><strong>Output:</strong> {word}</p>}
                {error && <p className="error">{error}</p>}
            </div>
      </div>
    );
}

export default App;