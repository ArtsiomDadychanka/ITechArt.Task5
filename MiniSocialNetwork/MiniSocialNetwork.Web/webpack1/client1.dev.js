const path = require('path');
const webpack = require('webpack');
//const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    devtool: 'inline-source-map',
    entry: [
        './ClientApp/main.jsx',
        './content/style/main.scss',
    ],
    output: {
        path: __dirname + '/../public/',
        filename: './js/bundle.js'
    },
    module: {
        rules: [{
                test: /\.(js|jsx?)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['react', 'env', 'stage-0'],
                    },
                },
            },
            {
                test: /\.(scss|sass)$/,
                use: ['style-loader', 'css-loader', 'sass-loader']
            },
            {
                test: /\.(png|jpg|gif|svg)$/,
                use: [{
                    loader: 'file-loader',
                    options: {}
                }]
            },
            {
                test: /\.(otf|eot|ttf|woff|woff2)$/,
                use: [{
                    loader: 'file-loader',
                    options: {}
                }]
            }
        ],
    },
    resolve: {
        extensions: ['.js', '.jsx']
    },
    plugins: [
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NamedModulesPlugin()
    ]
};