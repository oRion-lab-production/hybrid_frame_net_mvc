/// <binding BeforeBuild='Run - Development, Profile - Development' ProjectOpened='Profile - Development, Run - Development' />
"use strict";

const path = require('path');
const webpack = require('webpack');

module.exports = {
    mode: 'none',
    entry: "./wwwroot/js/app/index-webpack.js",
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'wwwroot/js')
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jquery: "jQuery",
            "window.jQuery": "jquery",
            axios: 'axios'
            //process: 'process/browser'
        }),
        new webpack.SourceMapDevToolPlugin({
            filename: "[file].map",
            fallbackModuleFilenameTemplate: '[absolute-resource-path]',
            moduleFilenameTemplate: '[absolute-resource-path]'
        })
    ],
    devtool: false,
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                loader: 'babel-loader'
                //options: {
                //    presets: [
                //        ['@babel/preset-env', { targets: "defaults" }]
                //    ]
                //}
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.(sa|sc|c)ss$/,
                use: ['style-loader', 'css-loader', 'sass-loader']
            },
            {
                test: /\.(png|svg|jpg|gif)$/,
                use: ['file-loader']
            },
            {
                test: /\.(woff|woff2|eot|ttf|otf)$/,
                use: ['file-loader']
            }
        ]
    },
    resolve: {
        alias: {
            vue: 'vue/dist/vue.js',
            jquery: "jquery/src/jquery"
        },
        extensions: ['.js', '.vue']
    }
};