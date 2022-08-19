pipeline {
    agent any
    tools {dotnetsdk "dnet"}
    stages {
        stage ('Passing token') {
            steps {
                script{
                    def jsonFileString = readFile file: "${WORKSPACE}/token.json"
                    jsonFileString = jsonFileString.replaceAll("YOUR_TOKEN", params.token)
                    writeFile file: "${WORKSPACE}/token.json", text: jsonFileString
                }
            }
        }
        stage ('Building Stage') {
            steps {
                sh 'dotnet build'
            }
        }
        stage ('Testing Stage') {
            steps {
                sh 'dotnet test'
            }
        }
        stage ('Allure report Stage') {
            steps {
                allure includeProperties: false,
                    jdk: '',
                    results: [[path: 'allure-results']]
            }
        }
    }
}