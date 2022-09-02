const path = require('path');

module.exports = {
    entry: {
        vendor: ['axios', 'typedi'],
        app: './src/app.ts'
    },
    devtool: 'inline-source-map',
    output: {
        path: path.resolve(__dirname, '../wwwroot'),
        filename: '[name].bundle.js',
    },
    resolve: {
        extensions: [".js", ".ts", ".scss"]
    },
    module: {
        rules: [
            {
                test: /\.ts(x?)$/,
                use: 'ts-loader',
                exclude: /node_modules/
            },
            {
                test: /\.s[ac]ss$/i,
                use: ['style-loader', 'css-loader', 'sass-loader']
            },
            {
                test: /\.html$/i,
                use: 'html-loader'
            }
        ]
    },
    mode: 'development'
}