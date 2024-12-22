using Elgin.Entities.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Driver
{
    public static partial class ElginDriver
    {
        // Abre conexão com a impressora
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int AbreConexaoImpressora(int tipo, string modelo, string conexao, int parametro);

        // Fecha conexão com a impressora
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FechaConexaoImpressora();

        // Altera o espaçamento entre linhas
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EspacamentoEntreLinhas(int tamanho);

        // Envia informações de texto para o buffer da impressora
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImpressaoTexto(string dados, int posicao, int estilo, int tamanho);

        // Realiza o corte do papel
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Corte(int avanco);

        // Realiza o corte total do papel
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CorteTotal(int avanco);

        // Impressão de QRCode
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImpressaoQRCode(string dados, int tamanho, int nivelCorrecao);

        // Impressão de código PDF417
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImpressaoPDF417(int numCols, int numRows, int width, int height, int errCorLvl, int options, string dados);

        // Impressão de código de barras
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImpressaoCodigoBarras(int tipo, string dados, int altura, int largura, int HRI);

        // Avança o papel
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AvancaPapel(int linhas);

        // Obtém o status da impressora
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StatusImpressora(int param);

        // Abre gavetas Elgin
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AbreGavetaElgin();

        // Abre gaveta
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AbreGaveta(int pino, int ti, int tf);

        // Inicializa a impressora
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InicializaImpressora();

        // Define a posição do conteúdo a ser impresso
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DefinePosicao(int posicao);

        // Emite sinal sonoro
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SinalSonoro(int qtd, int tempoInicio, int tempoFim);

        // Envia comandos ESC/POS direto para a porta de comunicação
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DirectIO(byte[] writeData, uint writeNum, byte[] readData, ref uint readNum);

        // Imprime imagem carregada em memória
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeImagemMemoria(string key, int scala);

        // Imprime Danfe SAT
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeXMLSAT(string dados, int param);

        // Imprime Danfe de cancelamento SAT
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeXMLCancelamentoSAT(string dados, string assQRCode, int param);

        // Imprime o Danfe NFCe
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeXMLNFCe(string dados, int indexcsc, string csc, int param);

        // ImprimeXMLCancelamentoNFCe
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeXMLCancelamentoNFCe(string dados, int param);

        // Habilita Modo Página
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ModoPagina();

        // Define Direção de Impressão
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DirecaoImpressao(int direcao);

        // Define Área Impressão
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DefineAreaImpressao(int oHorizontal, int oVertical, int dHorizontal, int dVertical);

        // Define Posição de Impressão Horizontal
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PosicaoImpressaoHorizontal(int nLnH);

        // Define Posição da Impressão Vertical
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PosicaoImpressaoVertical(int nLnH);

        // Imprime Modo Página
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImprimeModoPagina();

        // Limpa Buffer em Modo Página
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LimpaBufferModoPagina();

        // Imprime Modo Página e Retorna ao Modo Padrão
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImprimeMPeRetornaPadrao();

        // Retorna ao Modo Padrão
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ModoPadrao();

        // Retorna a versão da DLL
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint GetVersaoDLL();

        // Realiza a impressão do Cupom TEF
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeCupomTEF(string dados);

        // Imprime imagem do caminho especificado
        [DllImport("E1_Impressora01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ImprimeImagem(string path);
    }

}
