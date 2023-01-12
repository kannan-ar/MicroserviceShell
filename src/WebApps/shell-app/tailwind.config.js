module.exports = {
    prefix: '',
    mode: 'jit',
    content: [
      './src/**/*.{html,ts}'
    ],
    darkMode: 'media', // or 'media' or 'class'
    theme: {
      fontFamily: {
        sans: ['Helvetica Neue', 'Helvetica', 'Arial', 'sans-serif']
      },
      extend: {},
    },
    corePlugins: {
      preflight: true,
    },
    variants: {
      extend: {},
    },
    plugins: [require('@tailwindcss/typography')],
  };
  