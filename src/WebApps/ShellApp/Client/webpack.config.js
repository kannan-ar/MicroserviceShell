const path = require('path');

module.exports = {
    entry: './src/app.ts',
    devtool: 'inline-source-map',
    output: {
        path: path.resolve(__dirname, '../wwwroot'),
        filename: 'app.js'
    },
    resolve: {
        extensions: [".ts", ".scss"]
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
    mode: 'development',
}