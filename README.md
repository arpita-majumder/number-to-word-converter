# Number to Words Converter

This project is a web application that converts numerical inputs into words. The backend is built using .NET Core, and the frontend is developed using React with TypeScript.

## Features

- Convert numbers into words (e.g., "123.45" to "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS").
- User-friendly web interface for testing functionality.
- Built-in unit tests for backend validation.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- .NET 8 SDK installed on your machine.
- Node.js (version 14 or higher) installed.
- npm (comes with Node.js).
- A code editor like Visual Studio or Visual Studio Code.

## Getting Started

1. **Clone the repository to your local machine:**
  ```bash
   git clone <repository-url>
   cd NumberToWord
```

   Navigate to the backend directory:
  ```bash
  cd .\NumberToWordServer\
  ```  
        
  Restore the .NET dependencies:
  ```bash      
  dotnet restore
  ```
      
  Navigate to the frontend directory:
  ```bash 
  cd .\NumberToWordClient\
  ```
    
  Install the required npm packages:
  ```bash 
  npm install
  ```


2. **Building the Solution:**
    Navigate back to the backend directory:
     ```bash 
      cd .\NumberToWordServer\
    ``` 

    Build the solution:
     ```bash 
      dotnet build
    ```

    Frontend (React TypeScript)
     ```bash 
      cd .\NumberToWordClient\
    ```

    Build the React application:
     ```bash 
      npm run build
    ```


3. **Running the Application:**
    Navigate back to the backend directory:
     ```bash 
      cd .\NumberToWordServer\
      dotnet run
     ```

    Frontend (React TypeScript)
    Open a new terminal, navigate to the frontend directory:
     ```bash 
      cd .\NumberToWordClient\
     ```
    Start the React application:
     ```bash 
      npm start
    ``` 

    Interacting with the Application
    Open your web browser and navigate to http://localhost:3000 to access the React application.
    Enter a numerical value in the input field and click the "Convert" button.
    The converted words will be displayed below the input field.


4. **Testing:**
    Backend Tests
    Navigate to the backend directory:
    ```bash 
    cd .\NumberToWordServer\
    ```
    Run the unit tests using NUnit:
    ```bash 
    dotnet test
    ```
    
5. **CORS Configuration:**
    CORS is configured to allow requests from the React app running on http://localhost:3000. Ensure that this setting is in the Program.cs file of backend project.    
